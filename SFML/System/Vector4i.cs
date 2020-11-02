using System;

namespace SFML.System{
    public struct Vector4i : IEquatable<Vector4i> {
        
        public int X, Y, Z, W;

        public Vector4i(int x, int y, int z, int w){
            this.X=x;
            this.Y=y;
            this.Z=z;
            this.W=w;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Vector4i))
                return false;
            Vector4i other=(Vector4i)obj;
            if(other==this)
                return true;
            return false;
        }

        public bool Equals(Vector4i other){
            if(other==this)
                return true;
            return false;
        }

        public override int GetHashCode(){
            var hashCode=352033288;
            hashCode=hashCode*-1521134295+X.GetHashCode();
            hashCode=hashCode*-1521134295+Y.GetHashCode();
            hashCode=hashCode*-1521134295+Z.GetHashCode();
            hashCode=hashCode*-1521134295+W.GetHashCode();

            return hashCode;
        }

        public override string ToString(){
            return $"[Vector4i] X({X}) Y({Y}) Z({Z}) W({W})";
        }

        public static Vector4i operator +(Vector4i v1, Vector4i v2){
            return new Vector4i(v1.X+v2.X, v1.Y+v2.Y, v1.Z+v2.Z, v1.W+v2.W);
        }

        public static Vector4i operator -(Vector4i v){
            return new Vector4i(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Vector4i operator -(Vector4i v1, Vector4i v2){
            return new Vector4i(v1.X-v2.X, v1.Y-v2.Y, v1.Z-v2.Z, v1.W-v2.W);
        }

        public static Vector4i operator *(Vector4i v, int x){
            return new Vector4i(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4i operator *(int x, Vector4i v){
            return new Vector4i(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4i operator /(Vector4i v, int x){
            return new Vector4i(v.X/x, v.Y/x, v.Z/x, v.W/x);
        }

        public static bool operator ==(Vector4i v1, Vector4i v2){
            return v1.X==v2.X&&v1.Y==v2.Y&&v1.Z==v2.Z&&v1.W==v2.W;
        }

        public static bool operator !=(Vector4i v1, Vector4i v2){
            return v1.X!=v2.X||v1.Y!=v2.Y||v1.Z!=v2.Z||v1.W!=v2.W;
        }

        public static explicit operator Vector4f(Vector4i v){
            return new Vector4f(v.X, v.Y, v.Z, v.W);
        }

        public static explicit operator Vector4u(Vector4i v){
            return new Vector4u((uint)v.X, (uint)v.Y, (uint)v.Z, (uint)v.W);
        }
    }
}