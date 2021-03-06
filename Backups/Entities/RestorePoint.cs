using System;
using System.Collections.Generic;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        public RestorePoint(int amount, List<Storage> storages, DateTime creationTime)
        {
            Number = amount;
            _storages = storages;
            CreationTime = creationTime;
        }

        public IReadOnlyList<Storage> Storages => _storages;
        public int Number { get; }
        public DateTime CreationTime { get; }
    }
}