namespace Player
{
    public enum RESOURCE_TYPE
    {
        Gold,
        Wood,
        Meat
    }

    public class ResourceManager
    { 
        public int points = 0;

        public int startResources = 500;

        public Resource goldResource;
        public Resource woodResource;
        public Resource meatResource;

        public ResourceManager()
        {
            goldResource = new Resource(RESOURCE_TYPE.Gold, startResources);
            woodResource = new Resource(RESOURCE_TYPE.Wood, startResources);
            meatResource = new Resource(RESOURCE_TYPE.Meat, startResources);
        }

        public void AddResource(Resource _res, int _count)
        {
            _res.AddResourcesToCount(_count);
        }

        public void SubstractResource(Resource _res, int _count)
        {
            _res.SubstractResourcesToCount(_count);
        }

        public Resource GetResourceByResourceType(RESOURCE_TYPE _resType)
        {
            Resource res;

            switch (_resType)
            {
                case RESOURCE_TYPE.Gold:
                    res = goldResource;
                    return res;
                case RESOURCE_TYPE.Wood:
                    res = woodResource;
                    return res;
                case RESOURCE_TYPE.Meat:
                    res = meatResource;
                    return res;
                default:
                    return null;
            }
        }

    }

    public class Resource
    {
        RESOURCE_TYPE resType;
        public int count;

        public Resource(RESOURCE_TYPE _rType, int _count)
        {
            this.resType = _rType;
            this.count = _count;
        }

        public void AddResourcesToCount(int _count)
        {
            this.count += _count;
        }

        public void SubstractResourcesToCount(int _count)
        {
            this.count -= _count;
        }

        public void SetCount(int _count)
        {
            this.count = _count;
        }

        public int GetCount()
        {
            return this.count;
        }

        public void SetResourceType(RESOURCE_TYPE _type)
        {
            this.resType = _type;
        }

        public RESOURCE_TYPE GetResourceType()
        {
            return this.resType;
        }
        public bool CheckResourceCount(int _count)
        {
            if ((this.count - _count) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
