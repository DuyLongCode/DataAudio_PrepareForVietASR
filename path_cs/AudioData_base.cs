using CsvHelper.Configuration.Attributes;
namespace Audio;
public class AudioData
{
    [Name("client_id")]
    public string Client_Id{get;set;}
    [Name("path")]
    public string Path{get;set;}
    [Name("sentence")]
    public string Sentence{get;set;}
    [Name("up_votes")]
    public string Up_Votes{get;set;}
    [Name("down_votes")]
    public string Down_Votes{get;set;}
    [Name("age")]
    public string Age{get;set;}
    [Name("gender")]
    public string Gender{get;set;}
    [Name("accents")]
    public string Accents{get;set;}
    [Name("variant")]
    public string Variant{get;set;}
    [Name("locale")]
    public string Locale{get;set;}
    [Name("segment")]
    public string Segment{get;set;}
    
}