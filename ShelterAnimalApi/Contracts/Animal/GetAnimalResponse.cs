﻿namespace ShelterAnimalApi.Contracts.Animal
{
    public class GetAnimalResponse
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public int BreedId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Status { get; set; }
    }
}
