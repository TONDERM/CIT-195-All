// base Class 
class Flower
{
    private string name;
    protected string type;
    public string color;
    public Flower()
    {
        this.name = string.Empty;
        this.type = string.Empty;
        this.color = string.Empty;
    }
    public Flower(string name, string type, string color)
    {
        this.name = name;
        this.type = type;
        this.color = color;
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public virtual string getName()
    {
        return this.name;
    }
    public void setType(string type)
    {
        this.type = type;
    }
    public virtual string getType()
    {
        return this.type;
    }
}
class Tropical : Flower
{
    private string habitat;
    private bool bloom;

/*
    public Tropical()
        : base()
    {
        habitat = string.Empty;
        bloom = false;
    }
    public Tropical(string habitat, bool bloom)
        :base(name, type, color)
    {
        this.habitat = habitat;
        this.bloom = bloom;
    }
*/

    public override string getName()
    {
        return base.getName();
    }

    public override string getType()
    {
        return this.type;
    }

    public void setHabitat(string habitat)
    {
        this.habitat = habitat;
    }
    public virtual string getHabitat()
    {
        return this.habitat;
    }

    public void setBloom(bool bloom)
    {
        this.bloom = bloom;    
    }

    public virtual bool getBloom() 
    {
        return this.bloom;
    }


}

