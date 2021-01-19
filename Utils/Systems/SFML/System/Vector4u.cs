using System;

namespace SFML.System{
    public struct Vector4u : IEquatable<Vector4u> {
        
        public uint X, Y, Z, W;

        public Vector4u(uint x, uint y, uint z, uint w){
            this.X=x;
            this.Y=y;
            this.Z=z;
            this.W=w;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Vector4u))
                return false;
            Vector4u other=(Vector4u)obj;
            if(other==this)
                return true;
            return false;
        }

        public bool Equals(Vector4u other){
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
            return $"[Vector4u] X({X}) Y({Y}) Z({Z}) W({W})";
        }

        public static Vector4u operator +(Vector4u v1, Vector4u v2){
            return new Vector4u(v1.X+v2.X, v1.Y+v2.Y, v1.Z+v2.Z, v1.W+v2.W);
        }

        public static Vector4u operator -(Vector4u v1, Vector4u v2){
            return new Vector4u(v1.X-v2.X, v1.Y-v2.Y, v1.Z-v2.Z, v1.W-v2.W);
        }

        public static Vector4u operator *(Vector4u v, uint x){
            return new Vector4u(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4u operator *(uint x, Vector4u v){
            return new Vector4u(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4u operator /(Vector4u v, uint x){
            return new Vector4u(v.X/x, v.Y/x, v.Z/x, v.W/x);
        }

        public static bool operator ==(Vector4u v1, Vector4u v2){
            return v1.X==v2.X&&v1.Y==v2.Y&&v1.Z==v2.Z&&v1.W==v2.W;
        }

        public static bool operator !=(Vector4u v1, Vector4u v2){
            return v1.X!=v2.X||v1.Y!=v2.Y||v1.Z!=v2.Z||v1.W!=v2.W;
        }

        public static explicit operator Vector4f(Vector4u v){
            return new Vector4f(v.X, v.Y, v.Z, v.W);
        }

        public static explicit operator Vector4i(Vector4u v){
            return new Vector4i((int)v.X, (int)v.Y, (int)v.Z, (int)v.W);
        }
    }
}