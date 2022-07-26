import React, {FC} from 'react';
import {
  ListItemIcon, ListItemText, MenuList,
  MenuItem, Drawer, AppBar, IconButton,
  Toolbar, Typography, Divider, Container
} from '@material-ui/core';
import routes, {HOME, MY_ARTICLES, LOGIN, REGISTER, PREVIEW} from "./routes";
import {makeStyles} from "@material-ui/core/styles";
import CssBaseline from '@material-ui/core/CssBaseline';
import MenuIcon from '@material-ui/icons/Menu';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import clsx from 'clsx';
import MyArticlesContainer from "./articles/MyArticlesContainer";
import SignInSide from "./login/UserLogin";
import SignUp from "./login/SignUp";
import {Route} from 'react-router';

import ReviewTable from "./reviews/ReviewTable";
import Articles from "./articles/Articles";


const Link = require("react-router-dom").Link;
const withRouter = require("react-router-dom").withRouter;

type Props = {
  location: any,
  classes: any,
  theme: any,
  isLoggedIn: boolean,
}

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
  },
  toolbar: {
    paddingRight: 24,
  },
  toolbarIcon: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: '0 8px',
    ...theme.mixins.toolbar,
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
  },
  appBarShift: {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  menuButton: {
    marginRight: 36,
  },
  menuButtonHidden: {
    display: 'none',
  },
  title: {
    flexGrow: 1,
  },
  drawerPaper: {
    position: 'relative',
    whiteSpace: 'nowrap',
    width: drawerWidth,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerPaperClose: {
    overflowX: 'hidden',
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    width: theme.spacing(7),
    [theme.breakpoints.up('sm')]: {
      width: theme.spacing(9),
    },
  },
  appBarSpacer: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    height: '100vh',
    overflow: 'auto',
  },
  container: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4),
  },
  paper: {
    padding: theme.spacing(2),
    display: 'flex',
    overflow: 'auto',
    flexDirection: 'column',
  },
  fixedHeight: {
    height: 240,
  },
}));

const Sidebar: FC<Props> = (props) => {

  const classes = useStyles();
  const [open, setOpen] = React.useState(true);
  const handleDrawerOpen = () => {
    setOpen(true);
  };
  const handleDrawerClose = () => {
    setOpen(false);
  };

  function activeRoute(routeName: string) {
    return props.location.pathname.indexOf(routeName) > -1;
  }

  return (
    <div className={classes.root}>
      <CssBaseline/>
      <AppBar position="absolute" className={clsx(classes.appBar, open && classes.appBarShift)}>
        <Toolbar className={classes.toolbar}>
          <IconButton
            edge="start"
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            className={clsx(classes.menuButton, open && classes.menuButtonHidden)}
          >
            <MenuIcon/>
          </IconButton>
          <Typography component="h1" variant="h6" color="inherit" noWrap className={classes.title}>
            Covid Pubs 4 All
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        variant="permanent"
        classes={{
          paper: clsx(classes.drawerPaper, !open && classes.drawerPaperClose),
        }}
        open={open}
      >
        <div className={classes.toolbarIcon}>
          <IconButton onClick={handleDrawerClose}>
            <ChevronLeftIcon/>
          </IconButton>
        </div>
        <Divider/>
        <MenuList>
          {routes.map((prop: any, key: any) => {
            return (
              <Link to={prop.path} style={{textDecoration: 'none'}} key={key}>
                <MenuItem selected={activeRoute(prop.path)}>
                  <ListItemIcon>
                    <prop.icon/>
                  </ListItemIcon>
                  <ListItemText primary={prop.sidebarName}/>
                </MenuItem>
              </Link>
            );
          })}
        </MenuList>
        <Divider/>
      </Drawer>
      <main className={classes.content}>
        <div className={classes.appBarSpacer}/>
        <Container maxWidth="lg" className={classes.container}>
          <Route path={HOME} exact component={Articles}/>
          <Route path={MY_ARTICLES} exact component={MyArticlesContainer}/>
          <Route path={LOGIN} exact component={SignInSide}/>
          <Route path={REGISTER} exact component={SignUp}/>
          <Route path={PREVIEW} exact component={ReviewTable}/>
        </Container>
        </main>
    </div>
  );
}

export default withRouter(Sidebar);