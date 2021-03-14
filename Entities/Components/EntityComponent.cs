namespace Fish_Girlz.Entities.Components{
    public abstract class EntityComponent {
        public Entity ParentEntity{get;set;}

        public abstract void Init();
    }
}