using System;
using Backups.Interfaces;
using Backups.Services;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private IRepository _repository;
        public RestorePoint(int amount, IRepository repository, DateTime creationTime)
        {
            Amount = amount;
            _repository = repository;
            CreationTime = creationTime;
        }

        public int Amount { get; }
        public DateTime CreationTime { get; }
    }
}