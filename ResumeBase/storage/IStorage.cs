using ResumeBase.Model;
using System;

namespace ResumeBase.storage
{
    interface IStorage
    {
        void Clear();

        void Update(Resume resume);

        void Save(Resume resume);

        Resume Get(String uuid);

        void Delete(String uuid);

        Resume[] GetAll();

        int Count();
    }
}
