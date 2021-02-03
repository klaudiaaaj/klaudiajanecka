import axios from "axios";
import configuration from "../config.json";
import { FormikProps } from 'formik';

export const apiClient = axios.create({
  baseURL: configuration.apiUrl,
});

apiClient.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

export function inputProps<T>(props: FormikProps<T>, id: keyof T) {
  return {
    helperText: props.touched[id] && props.errors[id],
    error: props.touched[id] && props.errors[id] != null,
    value: props.values[id] ?? '',
    name: id,
    id,
    onBlur: props.handleBlur,
    onChange: props.handleChange,
  };
}
  