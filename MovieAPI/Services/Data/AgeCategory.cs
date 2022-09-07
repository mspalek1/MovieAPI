namespace MovieAPI.Services.Data
{
    public enum AgeCategory
    {
        GeneralAudience = 1,//G dla kazdego
        ParentalGuidance, //PG nieodpowiednie dla mlodszych
        ParentsStronglyCautioned, //PG-13 nieodpowiednie dla mlodszych niz 13 lat
        Restricted, //R - 17 lat
        NoOne17Under //NC-17 - dla doroslych
    }
}
