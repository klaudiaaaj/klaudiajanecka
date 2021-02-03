import React, {useEffect, useState} from 'react';
import {getPublishedArticles} from '../../api/articles';
import Grid from "@material-ui/core/Grid"
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";
import Table from "@material-ui/core/Table";
import Moment from 'react-moment';
import Button from "@material-ui/core/Button"
import {RouteComponentProps, withRouter} from "react-router";
import { GetArticleDtoResponse, GetCategoryDto, CategoryModel} from "../../api/Models/dto/dto";
import {getArticleFile, getArticlesByCategory} from "../../api/articles";
import PdfView from '../articleFile/pdfViwer';
import {Paper, TableContainer, MenuItem, FormControl, InputLabel} from "@material-ui/core";
import {Select,AppBar} from '@material-ui/core';
import Toolbar from '@material-ui/core/Toolbar';
import InputBase from '@material-ui/core/InputBase';
import { createStyles, fade, Theme, makeStyles} from '@material-ui/core/styles';
import SearchIcon from '@material-ui/icons/Search';
import {getCategory} from "../../api/categories"

type Props = RouteComponentProps & {}
const Articles = (props: Props) => {

  const [articles, setArticles] = useState<GetArticleDtoResponse[]>([]);
  const [searchedArticles, setSearchedArticles] = useState<GetArticleDtoResponse[]>([]);
  const [file, setFile] = useState<string>("");
  const [pdfViwer, setPdfViwer] = useState<boolean>(false);
  const [value, setValue] = React.useState<string>(""); 
  const [chosenCat, setChosenCat]= React.useState<number>(); 
  const [category, setCategory] = useState<CategoryModel[]>([]);
  const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
    }, 
    search: {
      position: 'relative',
      borderRadius: theme.shape.borderRadius,
      backgroundColor: fade(theme.palette.common.white, 0.15),
      '&:hover': {
        backgroundColor: fade(theme.palette.common.white, 0.25),
      },
      marginLeft: 0,  
      width: '100%',
      [theme.breakpoints.up('sm')]: {
        marginLeft: theme.spacing(1),
        width: 'auto',
      },
    },
    color: {
      color: "FFFFFF",
    },
    searchIcon: {
      padding: theme.spacing(0, 2),
      height: '100%',
      position: 'absolute',
      pointerEvents: 'none',
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
    },
    inputRoot: {
      color: 'inherit',
    },
    inputInput: {
      padding: theme.spacing(1, 1, 1, 0),
      // vertical padding + font size from searchIcon
      paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
      transition: theme.transitions.create('width'),
      width: '100%',
      [theme.breakpoints.up('sm')]: {
        width: '12ch',
        '&:focus': {
          width: '20ch',
        },
      },
    },
    header: {
      backgroundColor: '#ADD8E6'
    },
    cell_medium: {
      fontSize: "10px",      
      width: 250,
      color: 'inherit',
      minWidth: 1,
      marginLeft: "20px",
      backgroundColor: fade(theme.palette.common.white, 0.15),
      '&:hover': {
        backgroundColor: fade(theme.palette.common.white, 0.25),
      }, 
    },
    cell_short: {
      fontSize: "10px",
      width: 170,
    },
  }),
);

useEffect(() => {
  async function fetchData() {
    const stat = await getCategory();
    setCategory(stat);
  }

  fetchData();
}, []);
async function getArticlesCat(id: number) 
{ 
  setChosenCat(id);
  const newArticles = await getArticlesByCategory(id); 
  setSearchedArticles(newArticles)
}
  

  useEffect(() => {
    async function fetchData() {
      const stat = await getPublishedArticles();
      setArticles(stat);
      setSearchedArticles(stat);
    }

    fetchData();
  }, []);

  async function ViewFile(id: number) {
    getArticleFile(id)
      .then((resp) => {
        setFile(resp);
      })
  }
 
  const closePdfViewer = () => {
    setPdfViwer(false);
    setFile("");
  };
  const onClickViewPdf = (id: number) => {
    ViewFile(id);
    setPdfViwer(true);
  }

  const classes = useStyles();
  return (    
    <Grid>
       <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>                
          <div className={classes.search}>
            <div className={classes.searchIcon}>
              <SearchIcon />
            </div>
            <InputBase
              placeholder="Search…"
              classes={{
                root: classes.inputRoot,
                input: classes.inputInput,
              }}
              onChange={event => {   
                let currentlist = [];
                // if(chosenCat!=undefined)      
                // {//getArticlesCat(chosenCat);
                //   currentlist=searchedArticles
                // }              
                // else {
                //   currentlist= articles;
                // }
                currentlist=articles;
              let newlist =[];            
              newlist=currentlist.filter(item => {
              const lc = item; 
              const filter = event.target.value.toLowerCase(); 
              return lc.title.toLowerCase().includes(filter);
              })
                setSearchedArticles(newlist);
              }}             
              inputProps={{ 'aria-label': 'search' }}
            />
          </div>
          <FormControl variant="outlined"  className={classes.cell_medium}>
          <InputLabel id="demo-simple-select-error-label"> Category</InputLabel>
          <Select                  
                  label="Category"
                  placeholder="Choose a category"
                  onChange={(e) => {
                    getArticlesCat(e.target.value as number);                
                  }}>
                    {category.map((value: CategoryModel) => (
                    <MenuItem key={value.id} value={value.id}>{value.title} </MenuItem>
                  ))}
                </Select>
                </FormControl>               
        </Toolbar>
      </AppBar>
    </div>
      <TableContainer component={Paper}>
        <Table>
          <TableHead className={classes.header}>
            <TableRow>
              <TableCell>Title</TableCell>
              <TableCell>Category</TableCell>
              <TableCell>Author</TableCell>
              <TableCell>Created date</TableCell>              
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {searchedArticles
              .map(row => {
                return (
                  <TableRow>
                    <TableCell> {row.title} </TableCell>
                    <TableCell> {row.category.title} </TableCell>
                    <TableCell> {row.author.firstName} {row.author.lastName} </TableCell>
                    <TableCell>
                      <Moment date={row.createdAt} format="DD.MM.YYYY"/>
                    </TableCell>
                    <TableCell className={classes.cell_short}>
                      <Button variant="contained"
                              color="primary"
                              onClick={() => ViewFile(row.articleFileId)}
                      >
                        View Article
                      </Button>
                    </TableCell>
                  </TableRow>
                );
              })}
          </TableBody>
        </Table>
      </TableContainer>
      <PdfView
        open={pdfViwer}
        file={file}
        close={closePdfViewer}
      />
    </Grid>
  )
}

export default withRouter(Articles);