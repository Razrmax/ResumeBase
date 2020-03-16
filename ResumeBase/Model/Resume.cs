using System;
using System.Diagnostics.CodeAnalysis;

namespace ResumeBase.Model
{
    class Resume : IComparable<Resume>
    {
        private string _uuid;

        public Resume(string uuid)
        {
            _uuid = uuid;
        }

        public string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
            }
        }

        public override string ToString()
        {
            return _uuid;
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
            return _uuid.Equals(resume._uuid);
        }

        public int CompareTo([AllowNull] Resume other)
        {
            if (other == null) return 1;
            return this._uuid.CompareTo(other._uuid);
        }

        public override int GetHashCode()
        {
            return _uuid.GetHashCode();
        }
    }
}
