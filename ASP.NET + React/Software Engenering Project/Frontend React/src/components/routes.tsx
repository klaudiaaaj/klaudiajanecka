import DescriptionIcon from '@material-ui/icons/Description';
import LockOpenIcon from '@material-ui/icons/LockOpen';
import VpnKeyIcon from '@material-ui/icons/VpnKey';
import RateReviewIcon from '@material-ui/icons/RateReview';
import ReviewTable from "./reviews/ReviewTable";
import MyArticlesContainer from "./articles/MyArticlesContainer";
import SignInSide from "./login/UserLogin";
import SignUp from "./login/SignUp";
import Articles from "./articles/Articles";

export const HOME = '/home';
export const MY_ARTICLES = '/articles';
export const LOGIN = '/login';
export const REGISTER = '/register';
export const PREVIEW = '/preview';

const Routes = [
  {
    path: HOME,
    sidebarName: 'Articles',
    icon: DescriptionIcon,
    component: Articles,
  },
  {
    path: MY_ARTICLES,
    sidebarName: 'My Articles',
    icon: DescriptionIcon,
    component: MyArticlesContainer,
  },
  {
    path: PREVIEW,
    sidebarName: 'Preview',
    icon: RateReviewIcon,
    component: ReviewTable,
  },
  {
    path: LOGIN,
    sidebarName: 'Login',
    icon: LockOpenIcon,
    component: SignInSide,
  },
  {
    path: REGISTER,
    sidebarName: 'Register',
    icon: VpnKeyIcon,
    component: SignUp,
  },
];

export default Routes;