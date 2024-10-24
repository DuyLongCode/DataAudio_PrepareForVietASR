using Audio;
using Python.Runtime;
Runtime.PythonDLL=@"/Users/duylong/Code/enviroments/anaconda3/envs/viet-asr/lib/libpython3.10.dylib";


MetaData trainMetaData=new MetaData("/Users/duylong/Code/AI/DataAudio/train.tsv");
trainMetaData.PrePath="/media/sanslab/Data/DuyLong/english/DataAudio/data_80000/";
trainMetaData.CheckPath="/Users/duylong/Code/AI/DataAudio/data_80000/";

MetaDataProcess trainMetaDataProcess=new MetaDataProcess(trainMetaData.AddRecord(),"train.txt",trainMetaData.CheckPath);

trainMetaDataProcess.WriteFile();
// trainMetaDataProcess.WriteSentenceFile("train_sentence.txt");



MetaData testMetaData=new MetaData("/Users/duylong/Code/AI/DataAudio/test.tsv");
testMetaData.PrePath="/media/sanslab/Data/DuyLong/english/test_16391/";
testMetaData.CheckPath="/Users/duylong/Code/AI/DataAudio/test_16391/";

MetaDataProcess testMetaDataProcess=new MetaDataProcess(testMetaData.AddRecord(),"test.txt",testMetaData.CheckPath);

testMetaDataProcess.WriteFile();

