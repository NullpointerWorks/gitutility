echo(true)
if spawn([[push.bat]]) then
    expect("password:")
    echo(false)
    send("admin\r")
end
