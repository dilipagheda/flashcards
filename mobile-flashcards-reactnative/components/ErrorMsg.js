import React from 'react';
import { StyleSheet, View, Text, TextInput } from 'react-native';
import { red } from '../utils/colors';

function ErrorMsg(props) {
	return <Text style={styles.error}>{props.value}</Text>;
}

const styles = StyleSheet.create({
	error: {
		marginLeft: 10,
		color: red
	}
});

export default ErrorMsg;
