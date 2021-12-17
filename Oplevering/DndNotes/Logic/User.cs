using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Factory;


namespace Logic
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IUser iUser { get; set; }
        public INoteCollection inoteCollection { get; set; }

        private INoteCollection noteCollection;
        public User(UserDto userDto)
        {
            iUser = UserFactory.CreateUserfactory();
            inoteCollection = NotesFactory.GetNotesDal();
           noteCollection =  NotesFactory.GetNotesDal();
            Id = userDto.Id;
            Username = userDto.Username;
            Password = userDto.Password;
            Email = userDto.Email;

        }
        public User()
        {
            Id = 1;
            Username = "Art";
            noteCollection = NotesFactory.GetNotesDal();

        }

        /// <summary>
        /// Haalt Notes uit lijst van DTO's 
        /// </summary>
        /// <returns>
        /// Lijst<Notes> notes
        /// </returns>
        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            INoteCollection notesDal =  NotesFactory.GetNotesDal();
            foreach (var notesDto in notesDal.GetAllNotes())
            {
                notes.Add(new Note(notesDto));
            }
            return notes;
        }
        public Note GetNote(int Id)
        {
            
            INoteCollection noteCollection = NotesFactory.GetNotesDal();
            NotesDto notesDto = noteCollection.GetNote(Id);
            Note note = new Note(notesDto);

            
            
            return note;
        }
        public void  CreateNote(Note note)
        {
           

            NotesDto notesDto = new NotesDto()
            {
                Name = note.Name,
                Id = note.Id,
                Text = note.Text

            };
            noteCollection.CreateNote(notesDto, Id);
        }
        public void DeleteNote(Note note)
        {
            NotesDto notesDto = new NotesDto();
            
            notesDto.Id = note.Id;
            

            INoteCollection noteCollection = NotesFactory.GetNotesDal();
            noteCollection.DeleteNote(notesDto);


        }



        /// <summary>
        /// Haalt Characters uit lijst van DTO's 
        /// </summary>
        /// <returns>
        /// Lijst<Characters> characters
        /// </returns>
        public List<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();
            ICharacterCollection characterDal = CharacterFactory.GetCharacterCollectionDal();
            foreach (var characterDto in characterDal.GetAllCharacters())
            {
                characters.Add(new Character(characterDto));
            }
            return characters;
        }
        public Character GetCharacet(int Id)
        {

            ICharacterCollection characterCollection = CharacterFactory.GetCharacterCollectionDal();
            CharacterDto characterDto = characterCollection.GetCharacter(Id);
            Character character = new Character(characterDto);



            return character;
        }
        public void CreateCharacter(Character character)
        {
            ICharacterCollection characterCollection = CharacterFactory.GetCharacterCollectionDal();

            CharacterDto characterDto = new CharacterDto()
            {
                Name = character.Name,
                Id = character.Id,
                Icon = character.Icon,
                Colour = character.Colour,
                Class = character.Class,
                Race = character.Race
            };
            characterCollection.CreateCharacter(characterDto, Id);
        }
        public void DeleteCharacter(Character character)
        {
            CharacterDto characterDto = new CharacterDto();

            characterDto.Id = character.Id;


            ICharacterCollection characterCollection = CharacterFactory.GetCharacterCollectionDal();
            characterCollection.DeleteCharacter(characterDto);


        }

        /// <summary>
        /// Haalt Categorys uit lijst van DTO's 
        /// </summary>
        /// <returns>
        /// Lijst<Categorys> categories
        /// </returns>
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            ICategoryCollection categoryDal = CategoryFactory.GetCategoryDal();
            foreach (var categoryDto in categoryDal.GetAllCategorys())
            {
                categories.Add(new Category(categoryDto));
            }
            return categories;
        }
        public Category GetCategory(int Id)
        {

            ICategoryCollection categorycollection = CategoryFactory.GetCategoryDal();
            CategoryDto categoryDto = categorycollection.GetCategory(Id);
            Category category = new Category(categoryDto);



            return category;
        }
        public void CreateCategory(Category category)
        {
            ICategoryCollection categoryCollection = CategoryFactory.GetCategoryDal();

            CategoryDto categoryDto = new CategoryDto()
            {
                Name = category.Name,
                Id = category.Id,
                Icon = category.Icon,
                Colour = category.Colour
                

            };
            categoryCollection.CreateCategory(categoryDto, Id);
        }
        public void DeleteCategory(Category category)
        {
            CategoryDto categoryDto = new CategoryDto();

            categoryDto.Id = category.Id;


            ICategoryCollection categoryCollection = CategoryFactory.GetCategoryDal();
            categoryCollection.DeleteCategory(categoryDto);


        }
    }
}
