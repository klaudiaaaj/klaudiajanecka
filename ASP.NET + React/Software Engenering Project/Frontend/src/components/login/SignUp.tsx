/* eslint-disable no-template-curly-in-string */
import React, {FunctionComponent, useEffect, useState} from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import Select from '@material-ui/core/Select';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import {makeStyles} from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import {FormControl, FormGroup, FormLabel, InputLabel, MenuItem,} from "@material-ui/core";
import {CategoryModel, RegisterUserDto} from "../../api/Models/dto/dto";
import {postRegister} from "../../api/articles";
import {FormikProps} from "formik/dist/types";
import {withFormik} from "formik";
import * as Yup from 'yup';
import {inputProps} from "../../api/ApiClient";
import {LOGIN} from "../routes";
import {getCategory} from "../../api/categories";

type Props = {
  RegisterData?: RegisterUserDto;
  passwordConfirmation: string;
}

type FormValues = {
  FirstName: string;
  LastName: string;
  EmailAddress: string;
  OrcId: string;
  Password: string;
  isAuthor: boolean;
  isReviewer: boolean;
  passwordConfirmation: string;
  categoriesId: number[];
}

const formikEnhancer = withFormik<Props, FormValues>({
  enableReinitialize: true,
  validationSchema: Yup.object()
    .shape({
      FirstName: Yup.string()
        .required('First name is required')
        .max(18, 'Maximum input size is: ${max}'),
      LastName: Yup.string()
        .required('Last name is required')
        .max(18, 'Maximum input size is: ${max}'),
      EmailAddress: Yup.string().email()
        .required('E-mail is required')
        .max(30, 'Maximum input size is: ${max}'),
      OrcId: Yup.string()
        //.min(16,'ORCiD should have at least ${min} numbers')
        //.max(20,'ORCiD should have maximum ${min} characters')
        .required('ORCiD is required'),
      Password: Yup.string()
        .required('Password is required')
        .max(20, 'Password should have maximum ${max} characters')
        .min(7, 'Password should have at least ${min} characters '),
      passwordConfirmation: Yup.string()
        .oneOf([Yup.ref('Password')], 'Passwords must match')
        .max(20, 'Password should have maximum ${max} characters')
        .required("Password confirmation is required"),
      categoriesId: Yup.string()
        .required("Password confirmation is required"),
    }),

  mapPropsToValues: (props) => ({
    FirstName: props.RegisterData ? props.RegisterData.FirstName : '',
    LastName: props.RegisterData ? props.RegisterData.LastName : '',
    EmailAddress: props.RegisterData ? props.RegisterData.EmailAddress : '',
    OrcId: props.RegisterData ? props.RegisterData.OrcId : '',
    Password: props.RegisterData ? props.RegisterData.Password : '',
    isAuthor: props.RegisterData ? props.RegisterData.isAuthor : false,
    isReviewer: props.RegisterData ? props.RegisterData.isReviewer : false,
    passwordConfirmation: props.passwordConfirmation ? props.passwordConfirmation : '',
    categoriesId: props.RegisterData ? props.RegisterData.categoriesId : [],
  }),

  handleSubmit: (values) => {
    console.log(values);
    alert(JSON.stringify(values));
    postRegister(values);
  },

  displayName: 'SignUp',
});

const SignUp: FunctionComponent<Props & FormikProps<FormValues>> = (props) => {
  const classes = useStyles();
  const [category, setCategory] = useState<CategoryModel[]>([]);


  useEffect(() => {
    async function fetchData() {
      const stat = await getCategory();
      setCategory(stat);
    }

    fetchData();
  }, []);

  return (
    <Container maxWidth="xs">
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon/>
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <form className={classes.form} noValidate>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                {...inputProps(props, 'FirstName')}
                label="First Name"
                autoFocus
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                label="Last Name"
                {...inputProps(props, 'LastName')}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                {...inputProps(props, 'EmailAddress')}
                variant="outlined"
                required
                fullWidth
                label="Email Address"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                {...inputProps(props, 'OrcId')}
                variant="outlined"
                required
                fullWidth
                label="OrcId"
                type="orcid"
                rowsMax={4}
                placeholder="0000-0002-1825-0097"
              />
            </Grid>
            <Grid item xs={12}>
              <FormControl variant="outlined" className={classes.fullWidth}>
                <InputLabel>Category</InputLabel>
                <Select
                  {...inputProps(props, 'categoriesId')}
                  fullWidth
                  label="Category"
                >
                  {category.map((value: CategoryModel) => (
                    <MenuItem key={value.id} value={value.id}>{value.title} </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </Grid>
            <Grid item xs={12}>
              <TextField
                {...inputProps(props, 'Password')}
                variant="outlined"
                required
                fullWidth
                label="Password"
                type="password"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                {...inputProps(props, 'passwordConfirmation')}
                variant="outlined"
                required
                fullWidth
                label="Repeat password"
                type="password"
              />
            </Grid>
            <Grid item xs={12}>
              <FormControl required component="fieldset">
                <FormLabel component="legend">Select role</FormLabel>
                <FormGroup row>
                  <FormControlLabel
                    control=
                      {<Checkbox
                        {...inputProps(props, 'isAuthor')}/>}
                    label="Author"
                  />
                  <FormControlLabel
                    control={
                      <Checkbox
                        {...inputProps(props, 'isReviewer')}
                      />}
                    label="Reviewer"
                  />
                </FormGroup>
              </FormControl>
            </Grid>
          </Grid>
          <Button
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={() => props.handleSubmit()}
          >
            Sign Up
          </Button>
          <Grid container justify="flex-end">
            <Grid item>
              <Link href={LOGIN} variant="body2">
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </form>

      </div>
      <Box mt={5}>
        <Typography variant="body2" color="textSecondary" align="center">
          {'Copyright © Covid Pubs 4 All' + new Date().getFullYear()}
        </Typography>
      </Box>
    </Container>
  );
}

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%',
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  fullWidth: {
    width: '100%',
  },
}));
export default formikEnhancer(SignUp);

