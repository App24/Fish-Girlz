using System;

namespace SFML.System{
    public struct Vector4f : IEquatable<Vector4f> {
        
        public float X, Y, Z, W;

        public Vector4f(float x, float y, float z, float w){
            this.X=x;
            this.Y=y;
            this.Z=z;
            this.W=w;
        }

        public Vector4f(Vector2f v1, Vector2f v2){
            this.X=v1.X;
            this.Y=v1.Y;
            this.Z=v2.X;
            this.W=v2.Y;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Vector4f))
                return false;
            Vector4f other=(Vector4f)obj;
            if(other==this)
                return true;
            return false;
        }

        public bool Equals(Vector4f other){
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
            return $"[Vector4f] X({X}) Y({Y}) Z({Z}) W({W})";
        }

        public static Vector4f operator +(Vector4f v1, Vector4f v2){
            return new Vector4f(v1.X+v2.X, v1.Y+v2.Y, v1.Z+v2.Z, v1.W+v2.W);
        }

        public static Vector4f operator -(Vector4f v){
            return new Vector4f(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Vector4f operator -(Vector4f v1, Vector4f v2){
            return new Vector4f(v1.X-v2.X, v1.Y-v2.Y, v1.Z-v2.Z, v1.W-v2.W);
        }

        public static Vector4f operator *(Vector4f v, float x){
            return new Vector4f(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4f operator *(float x, Vector4f v){
            return new Vector4f(v.X*x, v.Y*x, v.Z*x, v.W*x);
        }

        public static Vector4f operator /(Vector4f v, float x){
            return new Vector4f(v.X/x, v.Y/x, v.Z/x, v.W/x);
        }

        public static bool operator ==(Vector4f v1, Vector4f v2){
            return v1.X==v2.X&&v1.Y==v2.Y&&v1.Z==v2.Z&&v1.W==v2.W;
        }

        public static bool operator !=(Vector4f v1, Vector4f v2){
            return v1.X!=v2.X||v1.Y!=v2.Y||v1.Z!=v2.Z||v1.W!=v2.W;
        }

        public static explicit operator Vector4i(Vector4f v){
            return new Vector4i((int)v.X, (int)v.Y, (int)v.Z, (int)v.W);
        }

        public static explicit operator Vector4u(Vector4f v){
            return new Vector4u((uint)v.X, (uint)v.Y, (uint)v.Z, (uint)v.W);
        }
    }
}