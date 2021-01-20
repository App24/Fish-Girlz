using System;

namespace Fish_Girlz.API{
    public class Version {
        public int VersionMajor { get; private set; }
        public int VersionMinor { get; private set; }
        public int VersionPatch { get; private set; }
        public string VersionString { get { return $"{VersionMajor}.{VersionMinor}.{VersionPatch}"; } }

        public Version(int versionMajor = 0, int versionMinor = 0, int versionPatch = 0)
        {
            VersionMajor = versionMajor;
            VersionMinor = versionMinor;
            VersionPatch = versionPatch;
        }

        public bool IsSameVersion(Version other)
        {
            return this==other;
        }

        public static Version CreateFromString(string version)
        {
            int[] versionsI = new int[] { 0, 0, 0 };
            string[] versions = version.Split('.');
            int length = versions.Length;
            if (length > 3)
                length = 3;
            if (!string.IsNullOrEmpty(version))
            {
                for (int i = 0; i < length; i++)
                {
                    versionsI[i] = int.Parse(versions[i]);
                }
            }
            return new Version(versionsI[0], versionsI[1], versionsI[2]);
        }

        public static bool operator >(Version a, Version b)
        {
            if (a.VersionMajor > b.VersionMajor)
            {
                return true;
            }
            else if (a.VersionMajor == b.VersionMajor && a.VersionMinor > b.VersionMinor)
            {
                return true;
            }
            else if (a.VersionMajor == b.VersionMajor && a.VersionMinor == b.VersionMinor && a.VersionPatch > b.VersionPatch)
            {
                return true;
            }
            return false;
        }


        public static bool operator <(Version a, Version b)
        {
            if (a.VersionMajor < b.VersionMajor)
            {
                return true;
            }
            else if (a.VersionMajor == b.VersionMajor && a.VersionMinor < b.VersionMinor)
            {
                return true;
            }
            else if (a.VersionMajor == b.VersionMajor && a.VersionMinor == b.VersionMinor && a.VersionPatch < b.VersionPatch)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Version a, Version b)
        {
            return a > b || a == b;
        }

        public static bool operator <=(Version a, Version b)
        {
            return a < b || a == b;
        }

        public static bool operator ==(Version a, Version b)
        {
            return a.VersionMajor == b.VersionMajor && a.VersionMinor == b.VersionMinor && a.VersionPatch == b.VersionPatch;
        }

        public static bool operator !=(Version a, Version b)
        {
            return !(a == b);
        }

        public override bool Equals(object other)
        {
            if (!(other is Version))
            {
                return false;
            }
            else
            {
                Version version = (Version)other;
                return this==version;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return VersionString;
        }
    }
}