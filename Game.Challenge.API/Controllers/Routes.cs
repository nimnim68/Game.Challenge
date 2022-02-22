namespace Game.Challenge.API.Controllers
{
    public class Routes
    {
        public const string ApiBaseRoute = "api";
        public const string UserBaseRoute = "/user";
        public const string UserAdminBaseRoute = "/userAdmin";
        public const string UserManageBaseRoute = "/userManage";
        public const string GameBaseRoute = "/game";

        public const string UserRoute = ApiBaseRoute + UserBaseRoute;
        public const string UserRouteAdmin = ApiBaseRoute + UserAdminBaseRoute;
        public const string UserRouteManage = ApiBaseRoute + UserManageBaseRoute;
        public const string GameRoute = ApiBaseRoute + GameBaseRoute;
    }
}
