echo(true)
if spawn([[clone.bat]]) then
    expect("password:")
    echo(false)
    send("admin\r")
end
