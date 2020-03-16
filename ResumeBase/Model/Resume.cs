using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ResumeBase.Model
{
    class Resume : IComparable<Resume>
    {
        private string uuid { get; set; }

        public override string ToString()
        {
            return uuid;
        }

        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }
            Resume resume = (Resume)o;
            return uuid.Equals(resume.uuid);
        }

        public int CompareTo([AllowNull] Resume other)
        {
            if (other == null) return 1;
            return this.uuid.CompareTo(other.uuid);
        }

        public override int GetHashCode()
        {
            return uuid.GetHashCode();
        }
    }
}
