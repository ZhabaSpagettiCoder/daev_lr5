//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace daev5lr.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class comments
    {
        public int CommentId { get; set; }
        public string Message { get; set; }
        public int MasterId { get; set; }
        public int RequestId { get; set; }
    
        public virtual requests requests { get; set; }
        public virtual users users { get; set; }
    }
}