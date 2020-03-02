using GitUtility.Config;
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
        public static string NewScript(string repoName, string localRepo, string remoteRepo)
        {
            string[] lines = new string[]
            {
                "cd /D "+localRepo, // jump to folder
                "git init", // initialize the folder as a git repository
                "git remote add origin "+remoteRepo, // add a reference to the remote repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("new.bat", lines);
            return DefaultExecution("new");
        }

        /// <summary>
        /// Restores missing files. Synchronizes with the remote repository.
        /// </summary>
        public static string FetchScript(RepoDetails repo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+repo.GetLocal(), // jump to folder
                "git fetch --prune origin",
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
        public static string PullScript(string localRepo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+localRepo,
                "git pull origin master",
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
                "git push origin master", // upload to repository
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
                "git push origin master", // upload to repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("commitpush.bat", lines);
            return DefaultLogin("commitpush", sd);
        }
        
        /// <summary>
        /// clones a remote repository to the provided git workspace
        /// </summary>
        public static string CloneScript(string localGit, string remoteRepo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd /D "+localGit, // jump to local workspace
                "git clone "+remoteRepo, // clone remote repo
                "exit"
            };
            FileUtil.WriteToFileUTF8("clone.bat", lines);
            return DefaultLogin("clone", sd);
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
