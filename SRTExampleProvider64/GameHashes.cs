using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SRTExampleProvider64
{
    /// <summary>
    /// SHA256 hashes for the RE3/BIO3 REmake game executables.
    /// 
    /// Resident Evil 3 (WW): https://steamdb.info/app/952060/ / https://steamdb.info/depot/952062/
    /// Biohazard 3 (CERO Z): https://steamdb.info/app/1100830/ / https://steamdb.info/depot/1100831/
    /// </summary>
    /// 

    public enum GameVersion
    {
        UNKNOWN,
        GameName_Region_ReleaseData_Patch
    }

    public static class GameHashes
    {
        // Ex Name: ResidentEvil1Classic_WorldWide_20210730_1_00
        private static readonly byte[] GameName_Region_ReleaseData_Patch_Revision = new byte[32] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

        public static GameVersion DetectVersion(string filePath)
        {
            byte[] checksum;
            using (SHA256 hashFunc = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                checksum = hashFunc.ComputeHash(fs);

            if (checksum.SequenceEqual(GameName_Region_ReleaseData_Patch_Revision))
                return GameVersion.GameName_Region_ReleaseData_Patch;
            else
                return GameVersion.UNKNOWN;
        }
    }
}