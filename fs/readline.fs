namespace Mal

module readline =

  open System
  open Mono.Terminal

  type Mode = Terminal | Raw

  let mutable mode = Mode.Terminal
  let lineedit = new LineEditor ("Mal")


  let ReadLine(prompt: string) : string =
    if (mode = Mode.Terminal) then
      lineedit.Edit(prompt, "")
    else
      Console.Write(prompt)
      Console.Out.Flush()
      Console.ReadLine()
