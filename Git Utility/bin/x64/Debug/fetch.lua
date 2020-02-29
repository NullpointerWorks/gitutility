echo(true)
if spawn([[fetch.bat]]) then
    expect("password:")
    echo(false)
    send("admin\r")
end
