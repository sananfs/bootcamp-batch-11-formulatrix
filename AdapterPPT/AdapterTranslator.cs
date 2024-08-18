namespace AdapterPPT;

public class AdapterTranslator : IBusiness
{
    private readonly Me _me;
    public AdapterTranslator(Me me){
        _me = me;
    }
    public void Nihonggo(){
        _me.India();
    }

}
