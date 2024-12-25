using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class AnimalService : IAnimalService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AnimalService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Animal>> GetAll()
        {
            return await _repositoryWrapper.Animal.FindAll();
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _repositoryWrapper.Animal
                .FindByCondition(x => x.AnimalId == id);
            return animal.First();
        }

        public async Task Create(Animal model)
        {
            await _repositoryWrapper.Animal.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Animal model)
        {
            _repositoryWrapper.Animal.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var animal = await _repositoryWrapper.Animal
                .FindByCondition(x => x.AnimalId == id);

            _repositoryWrapper.Animal.Delete(animal.First());
            await _repositoryWrapper.Save();
        }
    }
}