using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.Art;
using SFML;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fish_Girlz.Utils
{
    public static class Collision
    {
        static BitmaskManager bitmasks=new BitmaskManager();

        static Dictionary<Entity, List<Entity>> collidingEntities=new Dictionary<Entity, List<Entity>>();

        public static bool PixelPerfectTest(Sprite object1, Sprite object2, uint alphaLimit = 0)
        {
            FloatRect intersection;
            if(object1.GetGlobalBounds().Intersects(object2.GetGlobalBounds(), out intersection))
            {
                IntRect O1SubRect = object1.TextureRect;
                IntRect O2SubRect = object2.TextureRect;

                uint[] mask1 = bitmasks.GetMask(object1.Texture);
                uint[] mask2 = bitmasks.GetMask(object2.Texture);

                for(float i = intersection.Left; i < intersection.Left + intersection.Width; i++)
                {
                    for (float j = intersection.Top; j < intersection.Top + intersection.Height; j++)
                    {
                        Vector2f o1v = object1.InverseTransform.TransformPoint(i, j);
                        Vector2f o2v = object2.InverseTransform.TransformPoint(i, j);

                        if (o1v.X > 0 && o1v.Y > 0 && o2v.X > 0 && o2v.Y > 0 &&
                            o1v.X < O1SubRect.Width && o1v.Y < O1SubRect.Height &&
                            o2v.X < O2SubRect.Width && o2v.Y < O2SubRect.Height)
                        {
                            if(bitmasks.GetPixel(mask1, object1.Texture, Convert.ToUInt16(o1v.X+O1SubRect.Left), Convert.ToUInt16(o1v.Y+O1SubRect.Top))>alphaLimit&&
                               bitmasks.GetPixel(mask2, object2.Texture, Convert.ToUInt16(o2v.X + O2SubRect.Left), Convert.ToUInt16(o2v.Y + O2SubRect.Top)) > alphaLimit)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool CreateBitmask(Texture tex)
        {
            Image img = tex.CopyToImage();
            bitmasks.CreateMask(tex, img);
            return true;
        }

        /*public static bool CircleTest(Sprite object1, Sprite object2)
        {

        }*/

        public static bool CollideWithEntity(this Entity entity, Entity other){
            return BoundingBoxTest(entity, other);
        }
        
        //TODO: MEMORY LEAK ISSUE
        public static bool BoundingBoxTest(Entity object1, Entity object2)
        {
            CollisionComponent object1CC=object1.GetComponent<CollisionComponent>(typeof(CollisionComponent));
            CollisionComponent object2CC=object2.GetComponent<CollisionComponent>(typeof(CollisionComponent));
            if(object1CC==null||object2CC==null){
                return false;
            }
            OrientatedBoundingBox OBB1 = new OrientatedBoundingBox(object1, object1CC);
            OrientatedBoundingBox OBB2 = new OrientatedBoundingBox(object2, object2CC);

            Vector2f[] axis = new Vector2f[]
            {
                new Vector2f (OBB1.points[1].X-OBB1.points[0].X,
                              OBB1.points[1].Y-OBB1.points[0].Y),
                new Vector2f (OBB1.points[1].X-OBB1.points[2].X,
                              OBB1.points[1].Y-OBB1.points[2].Y),
                new Vector2f (OBB2.points[0].X-OBB2.points[3].X,
                              OBB2.points[0].Y-OBB2.points[3].Y),
                new Vector2f (OBB2.points[0].X-OBB2.points[1].X,
                              OBB2.points[0].Y-OBB2.points[1].Y)
            };

            bool colliding=true;
            for (int i = 0; i < 4; i++)
            {
                float minOBB1, maxOBB1, minOBB2, maxOBB2;

                OBB1.ProjectOntoAxis(axis[i], out minOBB1, out maxOBB1);
                OBB2.ProjectOntoAxis(axis[i], out minOBB2, out maxOBB2);
                if (!((minOBB2 <= maxOBB1) && (maxOBB2 >= minOBB1))){
                    colliding=false;
                }
            }
            if(colliding){
                if(!collidingEntities.ContainsKey(object1)){
                    object2CC.OnCollision?.Invoke(object2, new CollisionEventArgs(object1));
                    List<Entity> collidingEntity=new List<Entity>();
                    collidingEntity.Add(object2);
                    collidingEntities.AddOrReplace(object1, collidingEntity);
                }else{
                    List<Entity> collidingEntity=new List<Entity>();
                    if(collidingEntities.TryGetValue(object1, out collidingEntity)){
                        if(!collidingEntity.Contains(object2)){
                            object2CC.OnCollision?.Invoke(object2, new CollisionEventArgs(object1));
                            collidingEntity.Add(object2);
                            collidingEntities.AddOrReplace(object1, collidingEntity);
                        }
                    }
                }

                /*if(!collidingEntities.ContainsKey(object2)){
                    object2.OnCollision?.Invoke(object2, new CollisionEventArgs(object1));
                    List<Entity> collidingEntity=new List<Entity>();
                    collidingEntity.Add(object1);
                    collidingEntities.AddOrReplace(object2, collidingEntity);
                }else{
                    List<Entity> collidingEntity=new List<Entity>();
                    if(collidingEntities.TryGetValue(object2, out collidingEntity)){
                        if(!collidingEntity.Contains(object1)){
                            object2.OnCollision?.Invoke(object2, new CollisionEventArgs(object1));
                            collidingEntity.Add(object1);
                            collidingEntities.AddOrReplace(object2, collidingEntity);
                        }
                    }
                }*/
            }else{
                if(collidingEntities.ContainsKey(object1)){
                    List<Entity> collidingEntity=new List<Entity>();
                    if(collidingEntities.TryGetValue(object1, out collidingEntity)){
                        if(collidingEntity.Contains(object2)){
                            collidingEntity.Remove(object2);
                            collidingEntities.AddOrReplace(object1, collidingEntity);
                        }
                    }
                }

                /*if(collidingEntities.ContainsKey(object2)){
                    List<Entity> collidingEntity=new List<Entity>();
                    if(collidingEntities.TryGetValue(object2, out collidingEntity)){
                        if(collidingEntity.Contains(object1)){
                            collidingEntity.Remove(object1);
                            collidingEntities.AddOrReplace(object2, collidingEntity);
                        }
                    }
                }*/
            }

            if(!object1CC.Collidable)
                return false;
            if(!object2CC.Collidable)
                return false;
            return colliding;
        }
    }

    class BitmaskManager
    {
        private Dictionary<Texture, uint[]> bitmasks=new Dictionary<Texture, uint[]>();

        ~BitmaskManager()
        {
            foreach (var item in bitmasks.Reverse())
            {
                bitmasks.Remove(item.Key);
            }
        }

        public uint GetPixel(uint[] mask, Texture tex, uint x, uint y)
        {
            if (x >= tex.Size.X || y >= tex.Size.Y)
                return 0;
            uint t = x + y * tex.Size.X;
            return mask[t];
        }

        public uint[] GetMask(Texture tex)
        {
            uint[] mask;
            uint[] temp;
            bitmasks.TryGetValue(tex, out temp);
            KeyValuePair<Texture, uint[]> pair = new KeyValuePair<Texture, uint[]>(tex, temp);
            if(!bitmasks.ContainsKey(pair.Key))
            {
                Image img = tex.CopyToImage();
                mask = CreateMask(tex, img);
            }
            else
            {
                mask = pair.Value;
            }

            return mask;
        }

        public uint[] CreateMask(Texture tex, Image img)
        {
            uint[] mask = new uint[tex.Size.Y*tex.Size.X];

            for (uint y = 0; y < tex.Size.Y; y++)
            {
                for (uint x = 0; x < tex.Size.X; x++)
                {
                    mask[x + y * tex.Size.X] = img.GetPixel(x, y).A;
                }
            }

            bitmasks.Add(tex, mask);

            return mask;
        }

    }

    class OrientatedBoundingBox
    {
        public Vector2f[] points = new Vector2f[4];
        public OrientatedBoundingBox(Entity entity, CollisionComponent cc)
        {
            Transform trans = entity.ToLayeredSprite().Transform;
            IntRect local = cc.CollisionBounds;
            points[0] = trans.TransformPoint(local.Left, local.Top);
            points[1] = trans.TransformPoint(local.Width, local.Top);
            points[2] = trans.TransformPoint(local.Width, local.Height);
            points[3] = trans.TransformPoint(local.Left, local.Height);
        }

        public void ProjectOntoAxis(Vector2f axis, out float min, out float max)
        {
            min = (points[0].X * axis.X + points[0].Y * axis.Y);
            max = min;
            for (int j = 0; j < 4; j++)
            {
                float projection = (points[j].X * axis.X + points[j].Y * axis.Y);

                if (projection < min)
                    min = projection;
                if (projection > max)
                    max = projection;
            }
        }
    }

    public class CollisionEventArgs : EventArgs{
        public Entity Other{get;}
        public CollisionEventArgs(Entity other){
            Other=other;
        }
    }

    public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);
}
