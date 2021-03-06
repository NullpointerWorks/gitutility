﻿using GitUtility.Config;
using GitUtility.Util;

namespace GitUtility.Git
{
    /// <summary>
    /// Git commandline execution scripts using Expect to automate loggin in the server
    /// </summary>
    public class ScriptBuilder
    {
        /// <summary>
        /// new a script to create a new local repository
        /// </summary>
        public static string NewScript(RepoDetails rd)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to folder
                "git init", // initialize the folder as a git repository
                "git remote add "+rd.GetName()+" "+rd.GetRemote(), // add a reference to the remote repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("new.bat", lines);
            return DefaultExecution("new");
        }

        /// <summary>
        /// Restores missing files. Synchronizes with the remote repository.
        /// </summary>
        public static string FetchScript(RepoDetails rd, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to folder
                "git fetch --prune "+rd.GetName(), // or origin
                "git reset --hard master",
                "git clean -f -d", 
                "exit"
            };
            FileUtil.WriteToFileUTF8("fetch.bat", lines);
            return DefaultLogin("fetch", sd);
        }

        /// <summary>
        /// In its default mode, "git pull" is shorthand for "git fetch" followed by "git merge FETCH_HEAD"
        /// </summary>
        public static string PullScript(RepoDetails rd, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(),
                "git pull "+rd.GetName()+" master",
                "exit"
            };
            FileUtil.WriteToFileUTF8("pull.bat", lines);
            return DefaultLogin("pull", sd);
        }

        /// <summary>
        /// commit all changes
        /// </summary>
        public static string CommitScript(RepoDetails rd, string message)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to folder
                "git add -A", // stages all changes. "git add -A" is equivalent to "git add ." followed by "git add -u"
                //"git add .", // stages new files and modifications, without deletions
                //"git add -u", // stages modifications and deletions, without new files
                "git commit -am \""+message+"\"", // commit all changes with a message
                "exit"
            };
            FileUtil.WriteToFileUTF8("commit.bat", lines);
            return DefaultExecution("commit");
        }

        /// <summary>
        /// push commits to remote repository
        /// </summary>
        public static string PushScript(RepoDetails rd, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to folder
                "git push "+rd.GetName()+" master", // upload to repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("push.bat", lines);
            return DefaultLogin("push", sd);
        }

        /// <summary>
        /// commit all changes and push to remote repository
        /// </summary>
        public static string CommitAndPushScript(RepoDetails rd, ServerDetails sd, string message)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to folder
                "git add -A", // add all untracked, might make this optional later on
                "git commit -am \""+message+"\"", // commit all changes with a message
                "git push "+rd.GetName()+" master", // upload to repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("commitpush.bat", lines);
            return DefaultLogin("commitpush", sd);
        }
        
        /// <summary>
        /// clones a remote repository to the provided git workspace
        /// </summary>
        public static string CloneScript(RepoDetails rd, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to local workspace
                "git clone "+rd.GetRemote(), // clone remote repo
                "exit"
            };
            FileUtil.WriteToFileUTF8("clone.bat", lines);
            return DefaultLogin("clone", sd);
        }
        
        /// <summary>
        /// scans a file in the repo for differences compared to last commit
        /// </summary>
        public static string DifferenceFileScript(RepoDetails rd, string file)
        {
            string[] lines = new string[]
            {
                "cd /D "+rd.GetLocal(), // jump to local workspace
                "git diff -- "+file, // scan file differences
                "exit"
            };
            FileUtil.WriteToFileUTF8("diff-file.bat", lines);
            return DefaultExecution("diff-file");
        }

        // ==============================================================
        
        /**
         * creates a simple login lua script
         */
        private static string DefaultLogin(string filename, ServerDetails sd)
        {
            var lines = new string[]
            {
                "echo(true)",
                "if spawn([["+filename+".bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8(filename + ".lua", lines);
            return filename + ".lua";
        }

        /**
         * creates an execution lua script
         */
        private static string DefaultExecution(string filename)
        {
            var lines = new string[]
            {
                "echo(true)",
                "if spawn([["+filename+".bat]]) then",
                "end"
            };
            FileUtil.WriteToFileUTF8(filename+".lua", lines);
            return filename+".lua";
        }
    }
}
