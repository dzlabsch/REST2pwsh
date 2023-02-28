param(
       $arg1,
       $arg2
)

$message = "$arg1, $arg2" | convertto-json

return $message
