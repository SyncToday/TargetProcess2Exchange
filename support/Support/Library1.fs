module Support

let optionOfNullable (a : System.Nullable<'T>) = 
    if a.HasValue then
        Some a.Value
    else
        None

let nullableOfOption = function
    | None -> new System.Nullable<_>()
    | Some x -> new System.Nullable<_>(x)
