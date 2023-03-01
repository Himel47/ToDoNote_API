using AutoMapper;
using ToDoNoteAPI.Models;
using ToDoNoteAPI.Models.Dto;

namespace ToDoNoteAPI.MappingHelper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Note, NoteUpdateDto>();
            CreateMap<NoteUpdateDto, Note>();
        }
    }
}
