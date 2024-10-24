import soundfile as sf 

def PathToDuration(path:str)->str:
    audio, sr = sf.read(path)
    duration = str(len(audio) / sr)
    return duration