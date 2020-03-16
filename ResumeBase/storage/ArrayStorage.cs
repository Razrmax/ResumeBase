using ResumeBase.Model;
using System;

namespace ResumeBase.storage
{
    class ArrayStorage : AbstractArrayStorage
    {
        protected override void RemoveResume(int replacementIndex)
        {
            resumeStorage[replacementIndex] = resumeStorage[resumeCounter - 1];
        }

        protected override void AddResume(int replacementIndex, Resume resume)
        {
            resumeStorage[resumeCounter] = resume;
        }

        protected override int FindResumeIndex(String uuid)
        {
            int resumeIndex = 0;
            while (resumeIndex < resumeCounter)
            {
                if (resumeStorage[resumeIndex].Uuid.Equals(uuid))
                {
                    return resumeIndex;
                }
                resumeIndex++;
            }
            return -1;
        }
    }
}
