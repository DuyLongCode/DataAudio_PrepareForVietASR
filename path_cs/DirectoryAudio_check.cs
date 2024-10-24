namespace Audio;
public class DirectoryAudio
{
    string _path;
    HashSet<string> _myHashSet = new HashSet<string>();
    public DirectoryAudio(string path)
    {
        _path=path;
        var directoryPath = _path;
        var allFilePaths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

        int i=0;
        foreach (var filePath in allFilePaths)
        {
            // Console.WriteLine(filePath);
            _myHashSet.Add(filePath);
            i++;
            
        }
        Console.WriteLine($"Thành công thêm {i} files vào hash để check ");
    }
    public bool InOrNot(string path)
    {
        
        return _myHashSet.Contains(path);
    }
    
}

