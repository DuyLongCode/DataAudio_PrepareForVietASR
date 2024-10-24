using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;

namespace Audio;
public class MetaData
{
    List<AudioData> _listAudio;
    string _path;
    string _prePath;
    string _checkPath;

    public string Path
    {
        get 
        {  
            return _path;
        }
    }
    public string PrePath
    {
    	get
        {
        	return _prePath;
        }
        set
        {
        	_prePath=value;
        }
    }
    public string CheckPath
    {
    	get
        {
        	return _checkPath;
        }
        set
        {
        	_checkPath=value;
        }
    }
    public List<AudioData> ListOfAudio
    {
        get
        {
            return _listAudio;
        }
    }

    public MetaData(string path)
    {
        _path=path;
        _listAudio=new List<AudioData>();
    }
    
    // public List<Audio> ListOfAudio; /Users/duylong/Code/AI/DataAudio/train.tsv
    public List<AudioData> AddRecord()
    {
        AudioData oneRecords;
        DirectoryAudio directoryAudio=new DirectoryAudio(_checkPath);
        // string prePath="/duylong/english/DataAudio/data_80000/";

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "\t",
            BadDataFound=null
        };
        using (var reader = new StreamReader(_path))
        using( var csv = new CsvReader(reader, config))
        {
            csv.Read();
            csv.ReadHeader();
            int count=0;
            while (csv.Read())
            {

                var record = csv.GetRecord<AudioData>();
                string path=record.Path;
                string checkPath=_checkPath+path;
                path=_prePath+path;
                if(directoryAudio.InOrNot(checkPath))
                {
                    oneRecords=record;
                    oneRecords.Path=path;
                    // Console.WriteLine(oneRecords.Path);
                    _listAudio.Add(record);
                    count++;
                }
                
            }
            Console.WriteLine($"Thành công thêm {count} file vào file train/test");
        }
        return _listAudio;
    }

}