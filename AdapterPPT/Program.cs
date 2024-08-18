using AdapterPPT;
class Program{
    public static void Main(){
        Me me = new();
        IBusiness adapterTranslator = new AdapterTranslator(me);

        adapterTranslator.Nihonggo();
    }
}