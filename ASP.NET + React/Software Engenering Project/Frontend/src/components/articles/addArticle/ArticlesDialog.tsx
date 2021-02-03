import HighlightOffOutlinedIcon from "@material-ui/icons/HighlightOffOutlined";
import React, {useState} from 'react';
import DialogActions from "@material-ui/core/DialogActions";
import {CategoryModel, PostArticleDto, Status} from "../../../api/Models/dto/dto"
import {useForm} from "react-hook-form";
import Dropzone from "react-dropzone";
import {makeStyles} from '@material-ui/core/styles';
import {
  Button,
  Dialog,
  DialogContent,
  DialogTitle, TextField,
  useMediaQuery,
  Grid,
  useTheme,
  Select,
  MenuItem,
  InputLabel,
  Box, FormControl
} from '@material-ui/core';

interface Props {
  open: boolean;
  handleClose: () => void;
  addArticle: (FormData: PostArticleDto, File: File) => void;
  categoryList: CategoryModel[];
}

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 240,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
}));

const ArticlesDialog = (props: Props): JSX.Element => {
  const {handleSubmit, register, setValue} = useForm<PostArticleDto>({
    mode: "onSubmit",
    reValidateMode: "onChange",
  });
  const theme = useTheme();
  const fullScreen = useMediaQuery(theme.breakpoints.down('sm'));
  const [chosenCat, setChosenCat] = React.useState<string>("  ");
  const [status, setStatus] = React.useState<Status>();
  const [chosenCatID, setChosenCatID] = React.useState<number>();
  const [fileNames, setFileNames] = useState<File | null>(null);
  const classes = useStyles();

  const handleDrop = (acceptedFiles: File[]) => {
    setFileNames(acceptedFiles[0]);
  };
  const deleteFile = () => {
    setFileNames(null);
  };
  const save = (formData: PostArticleDto) => {
    if (fileNames && status)  {
      formData.categoryId = chosenCatID;
      props.addArticle(formData, fileNames)
      props.handleClose();
    } else
      console.log("No fille attached")
  }


  return (
    <Dialog
      fullScreen={fullScreen}
      open={props.open}
      onClose={props.handleClose}
      aria-labelledby="responsive-dialog-title"
      fullWidth={true}
      maxWidth = {'md'}

    >
      <DialogTitle id="responsive-dialog-title">{"Add Article"}</DialogTitle>
      <DialogContent>
        <form onSubmit={handleSubmit(save)}>
          <Grid container spacing={2} alignItems="center">
            <Grid item xs={6} sm={6}>
              <FormControl variant="outlined" className={classes.formControl}>
                <TextField
                  variant="outlined"
                  label="Title"
                  name="title"
                  inputRef={register}
                  onChange={(e) => {
                    setValue("title", e.target.value as string);
                  }
                  }/>
                 </FormControl>
              <FormControl variant="outlined" className={classes.formControl}>
                <InputLabel id="demo-simple-select-outlined-label">Category</InputLabel>
                <Select
                  labelId="demo-simple-select-outlined-label"
                  id="demo-simple-select-outlined"
                  defaultValue={""}
                  name="categoryId"
                  value={chosenCat}
                  inputRef={register}
                  label="Category"
                  onChange={(e) => {
                    setChosenCat(e.target.value as string);
                    setChosenCatID(e.target.value as number);
                  }}
                >
                  {props.categoryList.map((value: CategoryModel) => (
                    <MenuItem key={value.id} value={value.id}>{value.title} </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </Grid>
              <FormControl variant="outlined" className={classes.formControl}>
              <Dropzone onDrop={handleDrop} accept=".pdf, .doc, .docx">

                {({getRootProps, getInputProps}) => (
                  <div
                    {...getRootProps()}
                    style={{height: 125, border: "2px dashed  #3f51b5"}}
                    data-testid="dropzoneDiv"
                  >
                    <input {...getInputProps()} />
                    <p>{"Upload an article"}</p>
                  </div>
                )}
              </Dropzone>
              <Box mt={2}>
                {fileNames && (
                  <>
                    <strong>{"Files"}</strong>
                    <Box display="flex" justifyContent="space-around">
                      {fileNames.name}
                      <HighlightOffOutlinedIcon onClick={deleteFile}/>
                    </Box>
                  </>
                )}
              </Box>
              </FormControl>
          </Grid>
        </form>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleSubmit(save)} color="primary" autoFocus>
          Add
        </Button>
        <Button autoFocus onClick={props.handleClose} color="primary">
          Cancel
        </Button>
      </DialogActions>
    </Dialog>
  );

};

export default ArticlesDialog;