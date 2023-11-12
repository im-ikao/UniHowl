using System.IO;
using UniHowl.Domain;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace UniHowl
{
#if UNITY_WEBGL && UNITY_EDITOR
        public static class AudioBuildProcess
        {
            [PostProcessBuild(int.MinValue)]
            public static void OnPostBuild(BuildTarget target, string pathToBuildProject)
            {
                if (target != BuildTarget.WebGL)
                {
                    return;
                }

                var configuration = AudioConfiguration.GetInstance();
                var map = configuration.Audio;
                var howlerMap = map.ToHowlAudioMap();

                var audioFolder = "StreamingAssets\\Audio";
                var fullAudioPath = pathToBuildProject + "/" + audioFolder;
                if (Directory.Exists(fullAudioPath) == true)
                {
                    Directory.Delete(fullAudioPath, true);
                }

                CreateFolder(pathToBuildProject, audioFolder);

                var rootPath = pathToBuildProject + "/" + audioFolder;

                foreach (HowlAudio data in howlerMap.GetAll())
                {
                    if (string.IsNullOrEmpty(data.Id.Value) || string.IsNullOrEmpty(data.Name.Value))
                    {
                        continue;
                    }

                    CreateFolder(rootPath, data.Path.FolderPath);

                    var assetDataPath = Application.dataPath + @"\" + data.Path.FolderPath + data.Name.Value;
                    var newDataPath = rootPath + @"\" + data.Path.FolderPath + data.Name.Value;

                    assetDataPath = assetDataPath.Replace(@"\", "/");
                    newDataPath = newDataPath.Replace(@"\", "/");

                    FileUtil.CopyFileOrDirectory(assetDataPath, newDataPath);
                    FileUtil.DeleteFileOrDirectory(newDataPath + ".meta");
                }
            }

            private static void CreateFolder(string root, string path)
            {
                var separator = char.Parse("/");

                path = path.Replace(@"\", "/");
                var directory = path.Split(separator);
                var directoryPath = root;

                for (int index = 0; index < directory.Length; index++)
                {
                    var newDirectoryPath = directoryPath + "/" + directory[index];

                    if (Directory.Exists(newDirectoryPath) == false)
                    {
                        Directory.CreateDirectory(newDirectoryPath);
                    }

                    directoryPath = newDirectoryPath;
                }
            }
        }
    #endif
}