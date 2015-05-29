module step0_repl =

  open System
  open System.IO
  open Mal.readline

  let READ (str: string) =
    str

  let EVAL (ast: string) =
    ast

  let PRINT (exp: string) =
    exp

  let rep (str: string) =
    READ str |> EVAL |> PRINT


  let rec readloop () =
    try
      let input = ReadLine("user> ")
      match input with
        | null -> Console.Write "Exiting ..."
        | "" -> readloop()
        | _ ->
          printfn "%s" (rep input)
          readloop()
    with
      | :? IOException as e -> printfn "IOException: %s" e.Message


  [<EntryPoint>]
  let main argv =
    match argv with
      | [|"--raw"|] ->
        ignore(mode = Mal.readline.Mode.Raw)
        readloop()
      | _ -> readloop()
    0

