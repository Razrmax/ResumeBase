using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBase.Model
{
    class Resume : IComparable<Resume>
    {
        private string Uuid { get; set; }
    

        public Resume(String uuid)
        {
            this.Uuid = uuid;
        }

        
        public override string ToString()
        {
            return Uuid;
        }

        public int CompareTo(Resume r)
        {
            return Uuid.Compare(r.Uuid);
        }

        public override int GetHashCode()
        {
            return Uuid.has;
        }

        public override boolean Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || getClass() != o.getClass())
            {
                return false;
            }
            Resume resume = (Resume)o;
            return Uuid.equals(resume.Uuid);
        }
        
    }
}
