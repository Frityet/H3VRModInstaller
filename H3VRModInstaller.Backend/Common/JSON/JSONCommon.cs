using System.Collections.Generic;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.JSON.Common
{
    /// <summary>
    /// Common fields and functions for JSON!
    /// </summary>
    public class CommonJSON
    {
        /// <summary>
        /// All JSON files in the database!
        /// </summary>
        public string[] JsonFiles = Glob.FilesAndDirectories(H3VRModInstaller.Common.ModInstallerCommon.Modinstallerdir, "**.json").ToArray();
        /// <summary>
        /// Gets every filepath of the mods, and adds them to the list defined as the secont parameter
        /// </summary>
        /// <param name="FilesToSort">Files to sort</param>
        /// <param name="ListToAppendTo">List to Append to</param>
        /// <returns>Returns the list which was specified in second parameter</returns>
        public List<string> GetEachPath(string[] FilesToSort, List<string> ListToAppendTo)
        {
            
            return ListToAppendTo;
        }
        
    }
}