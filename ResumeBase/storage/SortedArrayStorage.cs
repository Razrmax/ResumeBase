using ResumeBase.Model;
using System;

namespace ResumeBase.storage
{
    class SortedArrayStorage : AbstractArrayStorage
    {
        protected override void RemoveResume(int replacementIndex)
        {
            if (resumeCounter - 1 - replacementIndex > 0)
            {
                Array.Copy(resumeStorage, replacementIndex + 1, resumeStorage, replacementIndex, resumeCounter - 1 - replacementIndex);
            }
        }

        protected override void AddResume(int replacementIndex, Resume resume)
        {
            replacementIndex = -replacementIndex - 1;
            if (resumeCounter - replacementIndex > 0)
            {
                Array.Copy(resumeStorage, replacementIndex, resumeStorage, replacementIndex + 1, resumeCounter - replacementIndex);
            }
            resumeStorage[replacementIndex] = resume;
        }

        protected override int FindResumeIndex(String uuid)
        {
            return Array.BinarySearch(resumeStorage, 0, resumeCounter, new Resume(uuid));
        }
    }
}
