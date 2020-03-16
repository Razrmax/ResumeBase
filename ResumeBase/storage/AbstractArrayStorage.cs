using ResumeBase.Model;
using System;

namespace ResumeBase.storage
{
    abstract class AbstractArrayStorage : IStorage
    {
        protected static readonly int STORAGE_LIMIT = 5;
        protected readonly Resume[] resumeStorage = new Resume[STORAGE_LIMIT];
        protected int resumeCounter = 0;

        public void Clear()
        {
            Array.Fill(resumeStorage, null, 0, resumeCounter);
            resumeCounter = 0;
        }

        public int Count()
        {
            return resumeCounter;
        }

        public Resume[] GetAll()
        {
            if (resumeCounter == 0)
            {
                return resumeStorage;
            }
            Resume[] newStorage = new Resume[STORAGE_LIMIT];
            Array.Copy(resumeStorage, 0, newStorage, 0, resumeCounter);
            return newStorage;
        }

        public Resume Get(String uuid)
        {
            int index = FindResumeIndex(uuid);
            if (index >= 0)
            {
                return resumeStorage[index];
            }
            Console.WriteLine("Resume with uuid \"" + uuid + "\" not found.");
            return null;
        }

        public void Update(Resume resume)
        {
            int index = FindResumeIndex(resume.Uuid);
            if (index >= 0)
            {
                resumeStorage[index] = resume;
            }
            else
            {
                Console.WriteLine("Resume with uuid \"" + resume.Uuid + "\" not found.");
            }
        }

        public void Delete(String uuid)
        {
            if (resumeCounter == 0)
            {
                Console.WriteLine("Error deleting entry from database. Resume database is empty!");
            }
            else
            {
                int resumeIndex = FindResumeIndex(uuid);
                if (resumeIndex < 0)
                {
                    Console.WriteLine("Resume with uuid \"" + uuid + "\" not found.");
                }
                else
                {
                    RemoveResume(resumeIndex);
                    resumeCounter--;
                    resumeStorage[resumeCounter] = null;
                }
            }
        }

        public void Save(Resume resume)
        {
            if (resumeCounter >= STORAGE_LIMIT)
            {
                Console.WriteLine("Error saving resume to database. Resume database is already full!");
            }
            else
            {
                int resumeIndex = FindResumeIndex(resume.Uuid);
                if (resumeIndex >= 0)
                {
                    Console.WriteLine("Resume with uuid \"" + resume.Uuid + "\" already exists.");
                }
                else
                {
                    AddResume(resumeIndex, resume);
                    resumeCounter++;
                }
            }
        }

        protected abstract void RemoveResume(int replacementIndex);

        protected abstract void AddResume(int replacementIndex, Resume resume);

        protected abstract int FindResumeIndex(String uuid);
    }
}
