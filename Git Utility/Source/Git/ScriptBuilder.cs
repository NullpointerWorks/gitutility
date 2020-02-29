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
                "cd "+localRepo, // jump to folder
                "git init", // initialize the folder as a git repository
                "git remote add "+repoName+" "+remoteRepo, // add a reference to the remote repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("new.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[new.bat]]) then",
                "end"
            };
            FileUtil.WriteToFileUTF8("new.lua", lines);
            return "new.lua";
        }
        
        /// <summary>
        /// Restores missing files. Synchronizes with the remote repository.
        /// </summary>
        public static string FetchScript(RepoDetails repo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd "+repo.GetLocal(), // jump to folder
                "git fetch --prune origin",
                "git reset --hard origin",
                "git clean -f -d", 
                "exit"
            };
            FileUtil.WriteToFileUTF8("fetch.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[fetch.bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8("fetch.lua", lines);
            return "fetch.lua";
        }

        /// <summary>
        /// In its default mode, "git pull" is shorthand for "git fetch" followed by "git merge FETCH_HEAD"
        /// </summary>
        public static string PullScript(string localRepo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd "+localRepo,
                "git pull origin master",
                "exit"
            };
            FileUtil.WriteToFileUTF8("pull.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[pull.bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8("pull.lua", lines);
            return "pull.lua";
        }

        /// <summary>
        /// commit all changes
        /// </summary>
        public static string CommitScript(RepoDetails rd, string message)
        {
            string[] lines = new string[]
            {
                "cd "+rd.GetLocal(), // jump to folder
                "git add -A", // add all untracked, might make this optional later on
                "git commit -am \""+message+"\"", // commit all changes with a message
                "exit"
            };
            FileUtil.WriteToFileUTF8("commit.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[commit.bat]]) then",
                "end"
            };
            FileUtil.WriteToFileUTF8("commit.lua", lines);
            return "commit.lua";
        }

        /// <summary>
        /// push commits to remote repository
        /// </summary>
        public static string PushScript(RepoDetails rd, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd "+rd.GetLocal(), // jump to folder
                "git push origin master", // upload to repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("push.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[push.bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8("push.lua", lines);
            return "push.lua";
        }

        /// <summary>
        /// commit all changes and push to remote repository
        /// </summary>
        public static string CommitAndPushScript(RepoDetails rd, ServerDetails sd, string message)
        {
            string[] lines = new string[]
            {
                "cd "+rd.GetLocal(), // jump to folder
                "git add -A", // add all untracked, might make this optional later on
                "git commit -a -m \""+message+"\"", // commit all changes with a message
                "git push origin master", // upload to repository
                "exit"
            };
            FileUtil.WriteToFileUTF8("commitpush.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[commitpush.bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8("commitpush.lua", lines);
            return "commitpush.lua";
        }
        




        /// <summary>
        /// clones a remote repository to the provided git workspace
        /// </summary>
        public static string CloneScript(string localGit, string remoteRepo, ServerDetails sd)
        {
            string[] lines = new string[]
            {
                "cd "+localGit, // jump to local workspace
                "git clone "+remoteRepo, // clone remote repo
                "exit"
            };
            FileUtil.WriteToFileUTF8("clone.bat", lines);
            lines = new string[]
            {
                "echo(true)",
                "if spawn([[clone.bat]]) then",
                "    expect(\"password:\")",
                "    echo(false)",
                "    send(\""+sd.GetPass()+"\\r\")",
                "end"
            };
            FileUtil.WriteToFileUTF8("clone.lua", lines);
            return "clone.lua";
        }
    }
}
