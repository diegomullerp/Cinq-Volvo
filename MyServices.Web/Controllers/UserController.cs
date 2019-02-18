namespace MyServices.Web.Controllers
{
    using System.Web.Http;
    using DTOs;

    [RoutePrefix("api/user")]
    [ControllerExceptionFilter]
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(_userService.Get(id));
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Add([FromBody] UserDTO userDTO)
        {
            var user = userDTO.ToUser();
            _userService.Add(user);
            return Created(string.Format("{0}/{1}", Request.RequestUri, user.Id), user);
        }

        [HttpPut]
        [ValidateModel]
        public IHttpActionResult Update([FromBody] UserDTO userDTO)
        {
            var user = userDTO.ToUser();
            _userService.Update(user);
            return Ok(_userService.Get(user.Id));
        }

        [Route("{id}")]
        public void Delete(string id)
        {
            _userService.Remove(id);
        }
    }
}