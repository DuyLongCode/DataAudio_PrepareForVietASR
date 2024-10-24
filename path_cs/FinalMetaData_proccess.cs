using CSCore;
using CSCore.Codecs;
using CSCore.SoundIn;
using Python.Runtime;
namespace Audio;
public class MetaDataProcess 
{
    List<FinalMetaData> _listOfMetaData;
    string _output;
    string _checkPath;
    public MetaDataProcess(List<AudioData> list,string output,string checkePath)
    {
        _output=output;
        _checkPath=checkePath;
        _listOfMetaData=Process(list);
        Console.WriteLine($"Khởi tạo thành công {_output} và {_checkPath}");
    }
    
    List<FinalMetaData> ListMetaData
    {
        get 
        {
            return _listOfMetaData;
        }
    }
    private string Duration(string path)
    {


        // Runtime.PythonDLL=@"/Users/duylong/Code/enviroments/anaconda3/envs/viet-asr/lib/libpython3.10.dylib";

        PythonEngine.Initialize();

        using (Py.GIL())

        {


            dynamic os=Py.Import("os");

            dynamic sys=Py.Import("sys");
            sys.path.append(os.getcwd());
            
            dynamic pyFunction=PyModule.Import("duration");

            PyString message=new PyString(path);

            dynamic result=pyFunction.InvokeMethod("PathToDuration",new PyObject[]{message});
            return result;
        }
    }
    private List<FinalMetaData> Process(List<AudioData> list)
    {
        List<FinalMetaData> listMetaData=new List<FinalMetaData>();
        foreach(AudioData audioData in list)
        {
            FinalMetaData metaData=new FinalMetaData();
            metaData.Path=audioData.Path;
            metaData.Sentence=audioData.Sentence;
            metaData.ReadingPath=_checkPath+audioData.Path.Split('/').Last();
            metaData.Duration=Duration(metaData.ReadingPath).ToString();
            listMetaData.Add(metaData);
        }
        return listMetaData;
    }
    public void WriteFile()
    {
    	using (var write =new StreamWriter(_output))
        {
            foreach(FinalMetaData file in _listOfMetaData)
            {
                file.Sentence=file.Sentence.ToLower();
                string line=$"{file.Path}|{file.Sentence}|{file.Duration}\n";
            	write.Write(line);
            	
            }
        }
        Console.WriteLine("Thành công ghi file");
    }
    public void WriteSentenceFile(string output)
    {
    	using (var write =new StreamWriter(output))
        {
            foreach(FinalMetaData file in _listOfMetaData)
            {
                file.Sentence=file.Sentence.ToLower();
                string line=$"{file.Sentence}\n";
            	write.Write(line);
            	
            }
        }
    }
}