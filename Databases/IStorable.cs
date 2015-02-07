using System;

namespace Extender.Databases
{
    public interface IStorable
    {
        Guid UniqueID { get; }

        byte[] GetHashData();
        void ForceNewUniqueID();
    }
}
