using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TCM.Core.Dto.TrainComponentDto;
using TCM.Core.Entities;
using TCM.Core.Exceptions;
using TCM.Core.Interfaces;
using TCM.Core.Interfaces.Repositories;

namespace TCM.Infrastructure.Services
{
    public class TrainComponentService : ITrainComponentService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TrainComponentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateComponentAsync(TrainComponentCreateRequest request)
        {
            var data = new TrainComponent()
            {
                Name = request.Name,
                UniqueNumber = request.UniqueNumber,
                CanAssignQuantity = request.CanAssignQuantity
            };
            await _unitOfWork.Repository<TrainComponent>().AddAsync(data);
            await _unitOfWork.SaveAsync();
            return data.Id;
        }

        public async Task<bool> UpdateComponentAsync(TrainComponentUpdateRequest request)
        {
            var component = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(request.Id);
            if (component == null) 
                return false;

            component.Name = request.Name;
            component.UniqueNumber = request.UniqueNumber;
            component.CanAssignQuantity = request.CanAssignQuantity;
            if (component.CanAssignQuantity)
                component.Quantity = request.Quantity;

            await _unitOfWork.Repository<TrainComponent>().UpdateAsync(component);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateQantityAsync(int id, int quantity)
        {
            var component = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(id);
            if (component == null)
                return false;

            if (!component.CanAssignQuantity)
                throw new BadRequestException("Assign quantity is not allowed");

            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity must be positive");

            component.Quantity = quantity;

            await _unitOfWork.Repository<TrainComponent>().UpdateAsync(component);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<TrainComponentResponse> GetById(int id)
        {
            var entity = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(id);
            return _mapper.Map<TrainComponentResponse>(entity);
        }

        public async Task<List<TrainComponentHierarchyResponse>> GetAllAsync(int? parentId = null, int pageIndex = 0, int pageSize = 10)
        {

            var query =  _unitOfWork.Repository<TrainComponent>().Entities
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .Include(u => u.Children);

            var components = parentId != null ?
                await query.Where(x => x.Id == parentId).ToListAsync() :
                await query.ToListAsync();

            return _mapper.Map<List<TrainComponentHierarchyResponse>>(components);

        }

        public async Task<bool> DeleteComponentAsync(int id)
        {
            var component = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(id);
            if (component == null)
                return false;

            await _unitOfWork.Repository<TrainComponent>().DeleteAsync(component);
            await _unitOfWork.SaveAsync();
            return true;
            
        }

        public async Task<bool> CreateRelationAsync(int parentId, int childId)
        {

            if (parentId.Equals(childId))
            {
                throw new InvalidOperationException("Self-Dependency not allowed");
            }

            if (await _unitOfWork.TrainComponents.CheckDependencyExists(parentId, childId))
            {
                throw new InvalidOperationException("Children already exists");
            }

            if (await _unitOfWork.TrainComponents.CheckCircularDependency(parentId, childId))
            {
                throw new InvalidOperationException("Circular dependency not allowed");

            }

            var parent = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(parentId);
            if (parent == null)
                return false;

            var child = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(childId);
            if (child == null)
                return false;

            parent.Children.Add(child);

            await _unitOfWork.Repository<TrainComponent>().UpdateAsync(parent);
            await _unitOfWork.SaveAsync();
            return true;

        }


        public async Task<bool> DeleteRelationAsync(int parentId, int childId)
        {
            var parent = _unitOfWork.Repository<TrainComponent>().Entities
                .Include(u => u.Children)
                .FirstOrDefault(u => u.Id == parentId);
            if (parent == null)
                return false;

            var child = await _unitOfWork.Repository<TrainComponent>().GetByIdAsync(childId);
            if (child == null)
                return false;

            if (parent.Children.Contains(child))
                parent.Children.Remove(child);

             await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
