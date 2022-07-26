import { makeStyles, createStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) =>
  createStyles({
    text: {
      fontSize: "2em",
      fontFamily: "Segoe UI Light",
    },
    list: {
      width: "100%",
      maxWidth: 400,
      minWidth: 400,
      margin: "0 auto",
      backgroundColor: theme.palette.background.paper,
      overflow: "auto",
      maxHeight: 600,
    },
    flexdiv: {
      display: "flex",
      [theme.breakpoints.down(950)]: {
        flexDirection: "column",
      },
    },
    listSection: {
      backgroundColor: "inherit",
      margin: "0 auto",
    },
    Data: {
      alignItems: "Center",
      width: "100%",
      margin: "0 auto",
      maxWidth: 300,
    },
    chart: {
      alignItems: "Center",
      margin: "0 auto",
      maxWidth: 600,
      [theme.breakpoints.down(1400)]: {
        width: 500,
      },
      [theme.breakpoints.down(1100)]: {
        width: 400,
      },
      [theme.breakpoints.down(950)]: {
        width: 300,
      },
    },
    paper: {
      backgroundColor: "#f8f8ff",
      marginLeft: 10,
      margin: "0 auto",
      width: "100%",
      textAlign: "center",
      height: "37rem",
      maxHeight: 1200,
      maxWidth: 1500,
      [theme.breakpoints.down(950)]: {
        marginTop: 20,
        maxWidth: 400,
        margin: "0 auto",
        overflow: "auto",
      },
    },
  })
);
export default useStyles;
